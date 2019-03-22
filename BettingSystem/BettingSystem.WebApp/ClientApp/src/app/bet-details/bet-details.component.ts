import { Component } from "@angular/core";
import { AngularEndpointsService } from "../../../watts/generated/angular-endpoints.service";
import { Interfaces } from '../../../watts/generated/interfaces';
import { Enums } from "../../../watts/generated/enums";
import { ActivatedRoute, Router } from "@angular/router";
import { CurrentBetService } from "../current-bet/current-bet.service";

@Component({
  selector: 'bet-details',
  templateUrl: './bet-details.component.html'
})
export class BetDetailsComponent {
  public bet: Interfaces.IBetView = null;
  public gameTypes: typeof Enums.GameType = Enums.GameType;

  constructor(private route: ActivatedRoute, private router: Router, public endpointsService: AngularEndpointsService, public currentBetService: CurrentBetService) {
    this.route.params.subscribe(params => {
      this.endpointsService.Bet.GetBet({ betId: params['betId'] }).call<Interfaces.IBetView>().then((data) => {
        console.log(data);
        if (!data)
          this.router.navigate(['']);
        this.bet = data;
      })
    });
  }

  public isGuessed(bet: Interfaces.IBetView) {
    return bet.games.every((game) => game.isGuessed);
  }

  public getBetTypeName = (betType: Enums.BetType) => this.currentBetService.getBetTypeName(betType);

}
