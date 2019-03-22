import { Enums } from './enums';
export namespace Interfaces {
    export interface IBetDto {
        betValue: number;
        coefficientIds: number[];
    }

    export interface IBetView {
        id: number;
        games: Interfaces.IGameResolutionView[];
        createdDateTime: string;
        isResolved: boolean;
        betValue: number;
        isResolvable: boolean;
    }

    export interface IGameResolutionView {
        gameType: Enums.GameType;
        firstTeamName: string;
        secondTeamName: string;
        firstTeamScore: number;
        secondTeamScore: number;
        dateTimeStarting: string;
        dateTimePlayed: string;
        isGuessed: boolean;
        betType: Enums.BetType;
        coefficientValue: number;
    }

    export interface ICoefficientView {
        id: number;
        gameId: number;
        betType: Enums.BetType;
        coefficientValue: number;
    }

    export interface IGameOfferView {
        bestOffers: Interfaces.IGameView[];
        otherOffers: Interfaces.IGameView[];
    }

    export interface IGameView {
        id: number;
        gameType: Enums.GameType;
        firstTeamName: string;
        secondTeamName: string;
        firstTeamScore: number;
        secondTeamScore: number;
        dateTimeStarting: string;
        dateTimePlayed: string;
        coefficients: Interfaces.ICoefficientView[];
    }

    export interface ITotalFundsView {
        totalFunds: number;
        transactions: Interfaces.IWalletTransactionView[];
    }

    export interface IWalletTransactionView {
        dateTimeUpdated: string;
        transactionValue: number;
        transactionType: Enums.TransactionType;
        betId: number;
    }
}
