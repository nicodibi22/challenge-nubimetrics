using challenge_nubimetrics_models.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_models.Mappings
{
    public class UsuarioMap : ClassMap<UsuarioEntity>
    {

        public UsuarioMap()
        {

            Table("Usuario");
            Id(x => x.Id).Column("Id").GeneratedBy.Identity(); ;
            Map(x => x.Nombre).Column("Nombre").Not.Nullable().Length(128);
            Map(x => x.Apellido).Column("Apellido").Not.Nullable().Length(128);
            Map(x => x.Email).Column("Email").Not.Nullable().Length(128);
            Map(x => x.Password).Column("Password").Nullable().Length(128);
            
        }
    }
}
