// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using ecommerce_apple.Server.RepositoriesSQL;
// using Microsoft.AspNetCore.Mvc;
// using SQLServerAPI.Models;

// namespace ecommerce_apple.Server.Controllers.Users
// {
//     [ApiController]
//     [Route("api/sqlserver/[controller]")]
//     public class AppleUserController : ControllerBase
//     {
//         private readonly IUserCollection _userCollection;

//         public AppleUserController(IUserCollection userCollection)
//         {
//             _userCollection = userCollection;
//         }

//         [HttpGet]
//         public async Task<IActionResult> GetAllUsers()
//         {
//             try
//             {
//                 var users = await _userCollection.GetAllUsers();
//                 return Ok(users);
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, $"Error 500: Internal server error {ex.Message}");
//             }
//         }

//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetUserById(int id)
//         {
//             try
//             {
//                 var user = await _userCollection.GetUsersById(id);

//                 if (user == null)
//                 {
//                     return NotFound($"Error 404: User with id {id} not found");
//                 }

//                 return Ok(user);
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, $"Error 500: Internal server error {ex.Message}");
//             }
//         }

//         [HttpPost]
//         public async Task<IActionResult> InsertUser([FromBody] UsersModel user)
//         {
//             try
//             {
//                 await _userCollection.InsertUser(user);
//                 return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, $"Error 500: Internal server error {ex.Message}");
//             }
//         }

//         [HttpPut("{id}")]
//         public async Task<IActionResult> UpdateUser(int id, [FromBody] UsersModel user)
//         {
//             try
//             {
//                 var existingUser = await _userCollection.GetUsersById(id);

//                 if (existingUser == null)
//                 {
//                     return NotFound($"Error 404: User with id {id} not found");
//                 }

//                 existingUser.NameUser = user.NameUser;
//                 existingUser.Email = user.Email;
//                 existingUser.Password = user.Password;
//                 existingUser.Directions = user.Directions;

//                 await _userCollection.UpdateUser(existingUser);

//                 return Ok(existingUser);
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, $"Error 500: Internal server error {ex.Message}");
//             }
//         }

//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteUser(int id)
//         {
//             try
//             {
//                 var user = await _userCollection.GetUsersById(id);

//                 if (user == null)
//                 {
//                     return NotFound($"Error 404: User with id {id} not found");
//                 }

//                 await _userCollection.DeleteUser(id);

//                 return Ok($"User with id {id} deleted successfully");
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, $"Error 500: Internal server error {ex.Message}");
//             }
//         }
//     }
// }
