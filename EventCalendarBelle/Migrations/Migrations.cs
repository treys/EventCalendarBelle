﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Persistence.Migrations;

namespace EventCalendarBelle.Migrations
{
    [Migration("2.0.1", 0, "UpdateEventCalendarTables")]
    public class EventMigration : MigrationBase
    {
        public override void Down()
        {
            Delete.Column("categories").FromTable("ec_events");
        }

        public override void Up()
        {
            Alter.Table("ec_events").AddColumn("categories").AsString(255).Nullable();
        }
    }

    [Migration("2.0.1", 1, "UpdateEventCalendarTables")]
    public class RecEventMigration : MigrationBase
    {
        public override void Down()
        {
            Delete.Column("categories").FromTable("ec_recevents");
        }

        public override void Up()
        {
            Alter.Table("ec_recevents").AddColumn("categories").AsString(255).Nullable();
        }
    }

    [Migration("2.0.2", 0, "UpdateEventCalendarTables")]
    public class CalendarTextColorMigration : MigrationBase
    {
        public override void Down()
        {
            Delete.Column("textcolor").FromTable("ec_calendars");
        }

        public override void Up()
        {
            Alter.Table("ec_calendars").AddColumn("textcolor").AsString(255).Nullable();
        }
    }

    [Migration("2.0.2", 1, "UpdateEventCalendarTables")]
    public class RecurringEventsTimesMigration : MigrationBase
    {
        public override void Down()
        {
            Delete.Column("start").FromTable("ec_recevents");
            Delete.Column("end").FromTable("ec_recevents");
        }

        public override void Up()
        {
            Alter.Table("ec_recevents").AddColumn("start").AsDateTime().Nullable();
            Alter.Table("ec_recevents").AddColumn("end").AsDateTime().Nullable();
        }
    }

    [Migration("2.0.3", 0, "UpdateEventCalendarTables")]
    public class EventsOrganisatorMigration : MigrationBase
    {
        public override void Down()
        {
            Delete.Column("organisator").FromTable("ec_recevents");
            Delete.Column("organisator").FromTable("ec_events");
        }

        public override void Up()
        {
            Alter.Table("ec_events").AddColumn("organisator").AsInt32().Nullable();
            Alter.Table("ec_events").AddColumn("organisator").AsInt32().Nullable();
        }
    }

    [Migration("2.0.5", 0, "UpdateEventCalendarTables")]
    public class CalendarGoogleApiKeyMigration : MigrationBase
    {
        public override void Down()
        {
            Delete.Column("apikey").FromTable("ec_calendars");
        }

        public override void Up()
        {
            Alter.Table("ec_calendars").AddColumn("apikey").AsString(255).Nullable();
        }
    }

    [Migration("2.1.0", 0, "UpdateEventCalendarTables")]
    public class MigrationBugFixingMigration : MigrationBase
    {
        public override void Down()
        {}

        public override void Up()
        {
            try
            {
                Alter.Table("ec_calendars").AddColumn("apikey").AsString(255).Nullable();
            }
            catch { }
        }
    }

    [Migration("2.1.2", 0, "UpdateEventCalendarTables")]
    public class OrganiserLanguageChangeMigration : MigrationBase
    {
        public override void Down()
        {
            Rename.Column("organiser").OnTable("ec_events").To("organisator");
            Rename.Column("organiser").OnTable("ec_recevents").To("organisator");
        }

        public override void Up()
        {
            Rename.Column("organisator").OnTable("ec_events").To("organiser");
            Rename.Column("organisator").OnTable("ec_recevents").To("organiser");
        }
    }

    [Migration("2.2.0", 0, "UpdateEventCalendarTables")]
    public class RecurringEventEnhancements : MigrationBase
    {
        public override void Down()
        {
            Delete.Column("rangeStart").FromTable("ec_recevents");
            Delete.Column("rangeEnd").FromTable("ec_recevents");
            Alter.Table("ec_recevents").AlterColumn("day").AsInt32();
            Alter.Table("ec_recevents").AlterColumn("monthly").AsInt32();
        }

        public override void Up()
        {
            Alter.Table("ec_recevents").AddColumn("rangeStart");
            Alter.Table("ec_recevents").AddColumn("rangeEnd");
            Alter.Table("ec_recevents").AlterColumn("day").AsFixedLengthString(255);
            Alter.Table("ec_recevents").AlterColumn("monthly").AsFixedLengthString(255);
        }
    }

    [Migration("2.3.0", 0, "EventEnhancements")]
    public class EventEnhancements : MigrationBase
    {
        public override void Down()
        {
            Delete.Column("media").FromTable("ec_recevents");
            Delete.Column("icon").FromTable("ec_recevents");
            Delete.Column("media").FromTable("ec_events");
            Delete.Column("icon").FromTable("ec_events");
        }

        public override void Up()
        {
            Alter.Table("ec_recevents").AddColumn("media").AsString();
            Alter.Table("ec_recevents").AddColumn("icon").AsString();
            Alter.Table("ec_events").AddColumn("media").AsString();
            Alter.Table("ec_events").AddColumn("icon").AsString();
        }
    }
}