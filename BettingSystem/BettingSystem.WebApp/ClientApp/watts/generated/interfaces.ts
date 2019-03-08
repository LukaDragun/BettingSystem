import { Enums } from './enums';
export namespace Interfaces {
    export interface ICoefficientView {
        id: number;
        betType: Enums.BetType;
        coefficientValue: number;
    }

    export interface IGameOfferView {
        bestOffers: Interfaces.IGameView[];
        otherGames: Interfaces.IGameView[];
    }

    export interface IGameView {
        id: number;
        firstTeamName: string;
        secondTeamName: string;
        firstTeamScore: number;
        secondTeamScore: number;
        dateTimeStarting: string;
        dateTimePlayed: string;
        coefficients: Interfaces.ICoefficientView[];
    }
}
