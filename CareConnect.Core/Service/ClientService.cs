using CareConnect.Core.IService;
using CareConnect.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareConnect.Core.Models;

namespace CareConnect.Core.Service
{
    public class ClientService: IClientService
    {
        private readonly CareConnectContext _context;
        public ClientService(CareConnectContext context)
        {
            _context = context;
        }
        public async Task<List<Client>> GetClients()
        {
            try
            {
                if (_context != null)
                {
                    return await (from c in _context.Clients
                            select new Client()
                            {
                                FirstName = c.FirstName,
                                Id = c.Id,
                                CellPhone = c.CellPhone,
                                LastName = c.LastName,
                                EntityAddress=c.EntityAddress,
                                PrimaryEmail=c.PrimaryEmail,
                                Dob=c.Dob
                            }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred:" + ex.Message);
            }
            return new List<Client>();
        }
        public async Task<bool> CreateorUpdateClient(ClientWrapper objClient)
        {
            bool isSuccess = false;
            try
            {
                if (objClient.ClientDetail.Id == 0)
                {
                    if (_context != null)
                    {

                        await _context.Clients.AddAsync(objClient.ClientDetail);
                        await _context.SaveChangesAsync();
                        objClient.Address.ClientId = objClient.ClientDetail.Id;
                        await _context.EntityAddress.AddAsync(objClient.Address);
                        await _context.SaveChangesAsync();
                        isSuccess = true;
                    }
                }
                else
                {
                    var client = await GetClientById(objClient.ClientDetail.Id);
                    if (client != null)
                    {
                        client.ClientDetail.FirstName = objClient.ClientDetail.FirstName;
                        client.ClientDetail.LastName = objClient.ClientDetail.LastName;
                        client.ClientDetail.MiddleName = objClient.ClientDetail.MiddleName;
                        client.ClientDetail.Dob = objClient.ClientDetail.Dob;
                        client.ClientDetail.PrimaryEmail = objClient.ClientDetail.PrimaryEmail;
                        client.ClientDetail.CellPhone = objClient.ClientDetail.CellPhone;
                        client.ClientDetail.Gender = objClient.ClientDetail.Gender;
                        client.ClientDetail.Notes = objClient.ClientDetail.Notes;
                        _context.Update(client.ClientDetail);
                        await _context.SaveChangesAsync();
                        isSuccess = true;
                    }
                    if(objClient.Address.Id>0)
                    {
                        var address =await _context.EntityAddress.Where(x => x.ClientId == objClient.ClientDetail.Id).FirstOrDefaultAsync();
                        if(address!=null)
                        {
                            address.AddressLine1 = objClient.Address.AddressLine1;
                            address.City = objClient.Address.City;
                            address.StateProvinceId = objClient.Address.StateProvinceId;
                            address.CountryRegionId = objClient.Address.CountryRegionId;
                            address.PostalCode = objClient.Address.PostalCode;
                            _context.Update(address);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            objClient.Address.ClientId = objClient.ClientDetail.Id;
                            await _context.EntityAddress.AddAsync(objClient.Address);
                            await _context.SaveChangesAsync();
                        }
                     
                    }
                    else
                    {
                        objClient.Address.ClientId = objClient.ClientDetail.Id;
                        await _context.EntityAddress.AddAsync(objClient.Address);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred:" + ex.Message);
            }
            return isSuccess;
        }

        public async Task<ClientWrapper> GetClientById(long ClientId)
        {
            ClientWrapper clientData = new ClientWrapper();
            try
            {
                if (_context != null)
                {
                 var client = await _context.Clients.Include(x => x.EntityAddress).Where(x => x.Id == ClientId).FirstOrDefaultAsync();
                    if(client!=null)
                    {
                        clientData.ClientDetail = client;
                        clientData.Address = client.EntityAddress.Any()? client.EntityAddress.FirstOrDefault():new EntityAddress();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred:" + ex.Message);
            }
            return clientData;
        }
    }
}
