// dto-interfaces.ts
export interface DtoBowler {
    bowlerName: string;
    bowlerImage: string;
    bowlerImageAltText: string;
    bowlerId: number;
    totalPins: number;
    totalGamesBowled: number;
    average: number;
    highestGame: number;
    highestSeries: number;
  }
  
  export interface DtoTeam {
    teamName: string;
    teamId: number; // Include teamId if it's needed
    bowlers: DtoBowler[];
  }
  
  export interface DtoLeague {
    leagueId: number;
    leagueName: string;
    leagueDescription: string;
    teams: DtoTeam[];
  }

  export interface DtoLeagueDetails {
    firstName: string;
    lastName: string;
    bowlerImage: string;
    bowlerImageAltText: string;
    bowlerId: number;
    leagueId: number;
    teamId: number;
    totalPins: number;
    totalGamesBowled: number;
    average: number;
    highestGame: number;
    highestSeries: number;
    teamName: string;
    leagueName: string;
    leagueDescription: string;
  }

  export interface DtoBowlerOnly {
    firstName: string;
    lastName: string;
    bowlerImage: string;
    bowlerImageAltText: string;
    bowlerId: number;
  }
  
  export interface DtoTeamOnly {
    teamName: string;
    teamId: number; // Include teamId if it's needed
  }
  
  export interface DtoLeagueOnly {
    leagueId: number;
    leagueName: string;
    leagueDescription: string;
    numberOfWeeks: number;
    handicapBase: number;
    maxBowlersPerTeam: number;
  }
  