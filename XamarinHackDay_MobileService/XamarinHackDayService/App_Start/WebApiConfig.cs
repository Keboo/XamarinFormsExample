using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using XamarinHackDayService.DataObjects;
using XamarinHackDayService.Models;

namespace XamarinHackDayService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize( new ConfigBuilder( options ) );

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            Database.SetInitializer( new XamarinHackDayInitializer() );
        }
    }

    public class XamarinHackDayInitializer : ClearDatabaseSchemaAlways<XamarinHackDayContext>
    {
        protected override void Seed( XamarinHackDayContext context )
        {
            List<Note> notes = new List<Note>
            {
                new Note 
                { 
                    Id = Guid.NewGuid().ToString(), 
                    Title = "My Seeded Note",
                    Text = "This is the first note created by the seed method on the database initializer"
                },
                new Note 
                { 
                    Id = Guid.NewGuid().ToString(), 
                    Title = "My Second Seeded Note",
                    Text = "Wow this is kidna cool"
                },
                new Note 
                { 
                    Id = Guid.NewGuid().ToString(), 
                    Title = "My Third Seeded Note",
                    Text = "Azure Mobile Services are really easy to use."
                }
            };

            foreach ( var note in notes )
            {
                context.Set<Note>().Add( note );
            }

            base.Seed( context );
        }
    }
}

