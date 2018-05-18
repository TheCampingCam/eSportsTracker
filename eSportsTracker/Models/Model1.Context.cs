﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eSportsTracker.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EsportsTrackerEntities1 : DbContext
    {
        public EsportsTrackerEntities1()
            : base("name=EsportsTrackerEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AttributesTable> AttributesTables { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<MatchAttribute> MatchAttributes { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlaysIn> PlaysIns { get; set; }
        public virtual DbSet<SoloMatch> SoloMatches { get; set; }
        public virtual DbSet<SponsoredBy> SponsoredBies { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamMatch> TeamMatches { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VideoGame> VideoGames { get; set; }
        public virtual DbSet<MatchesView> MatchesViews { get; set; }
        public virtual DbSet<TournamentDetail> TournamentDetails { get; set; }
        public virtual DbSet<TournamentDetailsExtended> TournamentDetailsExtendeds { get; set; }
        public virtual DbSet<MatchMaker> MatchMakers { get; set; }
        public virtual DbSet<MultiMatchMaker> MultiMatchMakers { get; set; }
        public virtual DbSet<statTable> statTables { get; set; }
        public virtual DbSet<PlayerWithWin> PlayerWithWins { get; set; }
        public virtual DbSet<PlayersInGame> PlayersInGames { get; set; }
        public virtual DbSet<TeamsWithWin> TeamsWithWins { get; set; }
    
        public virtual int MakeMatchEasy(Nullable<System.TimeSpan> iNPUT_TIME, Nullable<int> iNPUT_TOURNEY, Nullable<int> iNPUT_PLAYER1, Nullable<int> iNPUT_PLAYER2, Nullable<int> iNPUT_GAME)
        {
            var iNPUT_TIMEParameter = iNPUT_TIME.HasValue ?
                new ObjectParameter("INPUT_TIME", iNPUT_TIME) :
                new ObjectParameter("INPUT_TIME", typeof(System.TimeSpan));
    
            var iNPUT_TOURNEYParameter = iNPUT_TOURNEY.HasValue ?
                new ObjectParameter("INPUT_TOURNEY", iNPUT_TOURNEY) :
                new ObjectParameter("INPUT_TOURNEY", typeof(int));
    
            var iNPUT_PLAYER1Parameter = iNPUT_PLAYER1.HasValue ?
                new ObjectParameter("INPUT_PLAYER1", iNPUT_PLAYER1) :
                new ObjectParameter("INPUT_PLAYER1", typeof(int));
    
            var iNPUT_PLAYER2Parameter = iNPUT_PLAYER2.HasValue ?
                new ObjectParameter("INPUT_PLAYER2", iNPUT_PLAYER2) :
                new ObjectParameter("INPUT_PLAYER2", typeof(int));
    
            var iNPUT_GAMEParameter = iNPUT_GAME.HasValue ?
                new ObjectParameter("INPUT_GAME", iNPUT_GAME) :
                new ObjectParameter("INPUT_GAME", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MakeMatchEasy", iNPUT_TIMEParameter, iNPUT_TOURNEYParameter, iNPUT_PLAYER1Parameter, iNPUT_PLAYER2Parameter, iNPUT_GAMEParameter);
        }
    
        public virtual int insertTournament(Nullable<System.DateTime> date, string name, string organizer, string location, string game)
        {
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var organizerParameter = organizer != null ?
                new ObjectParameter("organizer", organizer) :
                new ObjectParameter("organizer", typeof(string));
    
            var locationParameter = location != null ?
                new ObjectParameter("location", location) :
                new ObjectParameter("location", typeof(string));
    
            var gameParameter = game != null ?
                new ObjectParameter("game", game) :
                new ObjectParameter("game", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertTournament", dateParameter, nameParameter, organizerParameter, locationParameter, gameParameter);
        }
    
        [DbFunction("EsportsTrackerEntities1", "getStats")]
        public virtual IQueryable<getStats_Result> getStats(Nullable<int> matchID, string handle)
        {
            var matchIDParameter = matchID.HasValue ?
                new ObjectParameter("matchID", matchID) :
                new ObjectParameter("matchID", typeof(int));
    
            var handleParameter = handle != null ?
                new ObjectParameter("handle", handle) :
                new ObjectParameter("handle", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<getStats_Result>("[EsportsTrackerEntities1].[getStats](@matchID, @handle)", matchIDParameter, handleParameter);
        }
    
        [DbFunction("EsportsTrackerEntities1", "getStatsV")]
        public virtual IQueryable<getStatsV_Result> getStatsV(Nullable<int> matchID)
        {
            var matchIDParameter = matchID.HasValue ?
                new ObjectParameter("matchID", matchID) :
                new ObjectParameter("matchID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<getStatsV_Result>("[EsportsTrackerEntities1].[getStatsV](@matchID)", matchIDParameter);
        }
    
        public virtual int MakeTeamMatchEasy(Nullable<System.TimeSpan> iNPUT_TIME, Nullable<int> iNPUT_TOURNEY, Nullable<int> iNPUT_TEAM1, Nullable<int> iNPUT_TEAM2, Nullable<int> iNPUT_GAME)
        {
            var iNPUT_TIMEParameter = iNPUT_TIME.HasValue ?
                new ObjectParameter("INPUT_TIME", iNPUT_TIME) :
                new ObjectParameter("INPUT_TIME", typeof(System.TimeSpan));
    
            var iNPUT_TOURNEYParameter = iNPUT_TOURNEY.HasValue ?
                new ObjectParameter("INPUT_TOURNEY", iNPUT_TOURNEY) :
                new ObjectParameter("INPUT_TOURNEY", typeof(int));
    
            var iNPUT_TEAM1Parameter = iNPUT_TEAM1.HasValue ?
                new ObjectParameter("INPUT_TEAM1", iNPUT_TEAM1) :
                new ObjectParameter("INPUT_TEAM1", typeof(int));
    
            var iNPUT_TEAM2Parameter = iNPUT_TEAM2.HasValue ?
                new ObjectParameter("INPUT_TEAM2", iNPUT_TEAM2) :
                new ObjectParameter("INPUT_TEAM2", typeof(int));
    
            var iNPUT_GAMEParameter = iNPUT_GAME.HasValue ?
                new ObjectParameter("INPUT_GAME", iNPUT_GAME) :
                new ObjectParameter("INPUT_GAME", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MakeTeamMatchEasy", iNPUT_TIMEParameter, iNPUT_TOURNEYParameter, iNPUT_TEAM1Parameter, iNPUT_TEAM2Parameter, iNPUT_GAMEParameter);
        }
    
        public virtual int DeleteMatches(Nullable<int> matchID)
        {
            var matchIDParameter = matchID.HasValue ?
                new ObjectParameter("MatchID", matchID) :
                new ObjectParameter("MatchID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteMatches", matchIDParameter);
        }
    
        [DbFunction("EsportsTrackerEntities1", "getStatsV1")]
        public virtual IQueryable<getStatsV1_Result> getStatsV1(Nullable<int> matchID)
        {
            var matchIDParameter = matchID.HasValue ?
                new ObjectParameter("matchID", matchID) :
                new ObjectParameter("matchID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<getStatsV1_Result>("[EsportsTrackerEntities1].[getStatsV1](@matchID)", matchIDParameter);
        }
    
        [DbFunction("EsportsTrackerEntities1", "getStatsVert")]
        public virtual IQueryable<getStatsVert_Result> getStatsVert(Nullable<int> matchID)
        {
            var matchIDParameter = matchID.HasValue ?
                new ObjectParameter("matchID", matchID) :
                new ObjectParameter("matchID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<getStatsVert_Result>("[EsportsTrackerEntities1].[getStatsVert](@matchID)", matchIDParameter);
        }
    
        [DbFunction("EsportsTrackerEntities1", "getStatsPair")]
        public virtual IQueryable<getStatsPair_Result> getStatsPair(Nullable<int> matchID)
        {
            var matchIDParameter = matchID.HasValue ?
                new ObjectParameter("matchID", matchID) :
                new ObjectParameter("matchID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<getStatsPair_Result>("[EsportsTrackerEntities1].[getStatsPair](@matchID)", matchIDParameter);
        }
    
        public virtual int AddStatistic(Nullable<int> matchID, string playerName, string statName, string statValue)
        {
            var matchIDParameter = matchID.HasValue ?
                new ObjectParameter("matchID", matchID) :
                new ObjectParameter("matchID", typeof(int));
    
            var playerNameParameter = playerName != null ?
                new ObjectParameter("playerName", playerName) :
                new ObjectParameter("playerName", typeof(string));
    
            var statNameParameter = statName != null ?
                new ObjectParameter("statName", statName) :
                new ObjectParameter("statName", typeof(string));
    
            var statValueParameter = statValue != null ?
                new ObjectParameter("statValue", statValue) :
                new ObjectParameter("statValue", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddStatistic", matchIDParameter, playerNameParameter, statNameParameter, statValueParameter);
        }
    }
}
