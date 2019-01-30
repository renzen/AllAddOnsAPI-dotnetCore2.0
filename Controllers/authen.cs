// using System;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.IdentityModel.Tokens;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;


// namespace AllAddOnsAPI.Controllers
// {

// public class AuthServiceController:Controller
// {
      
//      //Auth
//      [HttpPost]
//      [Route("api/token")]
//      public IActionResult Token(){

//          string yawe ="hfhfhfhlhfklhflhflhsklhflkshflhsfhlkshfklhfkhslfhlshfklshflkhsklfhslkhflshfklh";
//          var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(yawe));
//          var credential =  new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
//          var userClaim = new[]{new Claim(ClaimTypes.Name, "Renzen"),new Claim(ClaimTypes.MobilePhone, "9454934427")};
//          var token = new JwtSecurityToken(
//                 issuer:"http://localhost:5000",
//                 audience: "http://localhost:5000",
//                 expires:DateTime.Now.AddDays(1),
//                 claims: userClaim,
//                 signingCredentials:credential
//          );

//         string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
//          return Ok(tokenString);
//      }
// }
//       //Auth
// }