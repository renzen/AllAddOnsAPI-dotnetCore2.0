using System;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace AllAddOnsAPI.Controllers
{

public class AuthServiceController:Controller
{
      
     //Auth
     [HttpPost]
     [Route("api/token")]
     public IActionResult GetToken(){

         // key
         string securityKey ="my_super_long_secutiry_key_for_token_validation_project_all_add_on";

         //symmetric key
         var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

         //signing credentials
         var Credentials =  new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);

         // Claims
        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
        claims.Add(new Claim(ClaimTypes.Role, "Reader"));
        claims.Add(new Claim("Our_Custom_Claim", "Our Custom Value"));



        
         var token = new JwtSecurityToken(
                issuer:"renzen.net",
                audience: "readers",
                expires: DateTime.Now.AddDays(1),
                signingCredentials: Credentials,
                claims: claims
         );

         return Ok(new JwtSecurityTokenHandler().WriteToken(token));

    //    string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
    //      return Ok(tokenString);
     }
}
      //Auth
}