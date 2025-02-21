﻿using NotesApp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.Security
{
    public interface ISecurityTokenConstructor
    {
        Task<RespuestaAutenticacion> ConstruirToken(CredencialesUsuario cred);
    }
}
