﻿using BEUProyecto;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace WebApiMiVeci.Models
{
    internal static class TokenGenerator
    {
        public static string GenerateTokenJwt(Persona persona)
        {
            // RECUPERAMOS LAS VARIABLES DE CONFIGURACIÓN
            var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];

            // CREAMOS EL HEADER //
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var _Header = new JwtHeader(signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, persona.idPersona.ToString()),
                new Claim("Nombres", persona.nombres),
                new Claim("Apellidos", persona.apellidos),
                new Claim("Cedula", persona.cedula),
                new Claim(JwtRegisteredClaimNames.Email, persona.correo),
                new Claim(ClaimTypes.Role, persona.rol)
            };
            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: issuerToken,
                    audience: audienceToken,
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas.
                    expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime))
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}