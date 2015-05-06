using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using StreamBet.Models;

namespace StreamBet.Migrations
{
    [ContextType(typeof(ApplicationDbContext))]
    partial class initial
    {
        public override string Id
        {
            get { return "20150506062237_initial"; }
        }
        
        public override string ProductVersion
        {
            get { return "7.0.0-beta4-12943"; }
        }
        
        public override IModel Target
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Sequence");
                
                builder.Entity("StreamBet.Models.Streamer", b =>
                    {
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("Name")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("StreamLink")
                            .Annotation("OriginalValueIndex", 2);
                        b.Key("Id");
                    });
                
                return builder.Model;
            }
        }
    }
}
