import { Component } from "@angular/core";
import { AngularEndpointsService } from "../../../watts/generated/angular-endpoints.service";
import { Interfaces } from '../../../watts/generated/interfaces';
import { Enums } from "../../../watts/generated/enums";

@Component({
  selector: 'bet-list',
  templateUrl: './bet-list.component.html'
})
export class BetListComponent {
  public bets: Interfaces.IBetView[] = null;
  public transactionTypes: typeof Enums.TransactionType = Enums.TransactionType;

  constructor(public endpointsService: AngularEndpointsService) {
    this.endpointsService.Bet.GetBets().call<Interfaces.IBetView[]>().then((data) => {
      this.bets = data;
    })
  }

  public isGuessed(bet: Interfaces.IBetView) {
    return bet.games.every((game) => game.isGuessed);
  }

}
