// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using ecommerce_apple.Server.Repositories.SQLServer;
// using ecommerce_apple.Server.RepositoriesSQL;
// using Microsoft.EntityFrameworkCore;
// using SQLServerAPI.Models;

// namespace ecommerce_apple.Server.Repositories.UserCollections
// {
//     public class UserCollection : IUserCollection
//     {
//         private readonly SQLServerRepository _context;

//         public UserCollection(SQLServerRepository context)
//         {
//             _context = context;
//         }

//         public async Task<List<UsersModel>> GetAllUsers()
//         {
//             return await _context.Users.ToListAsync();
//         }

//         public async Task<UsersModel> GetUsersById(int id)
//         {
//             var user = await _context.Users.FindAsync(id);

//             if (user == null)
//             {
//                 throw new Exception($"Error 404: User with id {id} not found");
//             }

//             return user;
//         }

//         public async Task InsertUser(UsersModel user)
//         {
//             _context.Users.Add(user);
//             await _context.SaveChangesAsync();
//         }

//         public async Task UpdateUser(UsersModel user)
//         {
//             _context.Entry(user).State = EntityState.Modified;
//             await _context.SaveChangesAsync();
//         }

//         public async Task DeleteUser(int id)
//         {
//             var user = await _context.Users.FindAsync(id);
//             if (user != null)
//             {
//                 _context.Users.Remove(user);
//                 await _context.SaveChangesAsync();
//             }
//         }
//     }

// }