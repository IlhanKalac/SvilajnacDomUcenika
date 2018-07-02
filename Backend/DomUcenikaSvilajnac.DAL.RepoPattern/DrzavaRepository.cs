﻿using DomUcenikaSvilajnac.Common.Interfaces;
using DomUcenikaSvilajnac.Common.Models;
using DomUcenikaSvilajnac.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomUcenikaSvilajnac.DAL.RepoPattern
{
    public class DrzavaRepository : Repository<Drzava>, IDrzavaRepository
    {
        /// <summary>
        /// Nasledjuje genericku klasu Repository sa tipom Drzava i IDrzavaRepository interfejs
        /// Videti Repository i Drzava klasu i IDrzavaRepository interfejs radi dodatnog pojasnjena.
        /// </summary>
        public DrzavaRepository(UcenikContext context) : base (context)
        {

        }

        /// <summary>
        /// Get the context.
        /// </summary>
        public UcenikContext context
        {
            get { return context as UcenikContext; }
        }
    }
}
