import { Injectable } from "@angular/core";
import { Interfaces } from '../../../watts/generated/interfaces';
import { Enums } from "../../../watts/generated/enums";

@Injectable()
export class CurrentBetService {
  constructor() { }

  public currentBets: IBetCoefficientView[] = [];

  public getCurrentBetCount = () => this.currentBets.length;

  public isBetAlreadyPlaced = (coefficientId: number, gameId: number) => !!this.currentBets.find((item) => item.gameId === gameId && item.id == coefficientId);

  public placeBetOnCoefficient = (gameId: number, gameType: string, firstTeamName: string, secondTeamName: string, isSpecialOffer: boolean, coefficient: Interfaces.ICoefficientView) => {
    let isBetAlreadyPlaced = this.isBetAlreadyPlaced(coefficient.id, gameId);
    this.currentBets = this.currentBets.filter((el) => el.gameId !== gameId);

    if (isSpecialOffer) {
      this.currentBets = this.currentBets.filter((el) => !el.isSpecialOffer);
    }

    if (!isBetAlreadyPlaced) {
      this.currentBets.push({
        gameId: gameId,
        gameType: gameType,
        firstTeamName: firstTeamName,
        secondTeamName: secondTeamName,
        isSpecialOffer: isSpecialOffer,
        ...coefficient
      })
    }
  }

  public getBetTypeName(betType: Enums.BetType) {
    switch (betType) {
      case Enums.BetType.One:
        return "1";
      case Enums.BetType.Two:
        return "2";
      case Enums.BetType.OneTwo:
        return "12";
      case Enums.BetType.X:
        return "X";
      case Enums.BetType.XOne:
        return "X1";
      case Enums.BetType.XTwo:
        return "X2";
    }
  }


}

export interface IBetCoefficientView extends Interfaces.ICoefficientView {
  gameId: number;
  gameType: string;
  firstTeamName: string;
  secondTeamName: string;
  isSpecialOffer: boolean;
}
