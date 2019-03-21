import { Component, OnInit } from '@angular/core';
import { Enums } from '../../../watts/generated/enums';
import { AngularEndpointsService } from '../../../watts/generated/angular-endpoints.service';
import { Interfaces } from '../../../watts/generated/interfaces';
import { IBetCoefficientView, CurrentBetService } from './current-bet.service';
import { Options } from 'ng5-slider';

@Component({
  selector: 'current-bet',
  templateUrl: './current-bet.component.html',
})
export class CurrentBetComponent {

  betValue: number = 1;
  options: Options = null

  public selectedCoefficients: IBetCoefficientView[];

  constructor(public currentBetService: CurrentBetService, public endpointsService: AngularEndpointsService) {
    this.selectedCoefficients = this.currentBetService.currentBets;

    console.log(this.selectedCoefficients);

    endpointsService.Wallet.GetTotalFunds({ includeTransactions: false }).call<Interfaces.ITotalFundsView>().then((data) => {
      this.options = {
        floor: 1,
        ceil: data.totalFunds
      };
    })
  }

  public removeCoefficient = (index: number) => this.selectedCoefficients.splice(index, 1);
  public getCoefficientValue = () => this.selectedCoefficients.map(el => el.coefficientValue).reduce((acc, value) => acc * value);
  public getProfitValue = () => this.getCoefficientValue() * (95 * this.betValue) / 100;
  public reloadFunds = () => {
    this.endpointsService.Wallet.GetTotalFunds({ includeTransactions: false }).call<Interfaces.ITotalFundsView>().then((data) => {
      this.options = {
        floor: 1,
        ceil: data.totalFunds
      };
    });
  }

  public getBetTypeName = (betType: Enums.BetType) => this.currentBetService.getBetTypeName(betType);

  public placeBet() {
    let dto = <Interfaces.IBetDto>{
      betValue : this.betValue,
      coefficientIds : this.selectedCoefficients.map(el => el.id)
    }

    this.endpointsService.Bet.PlaceBet().call<boolean>(dto).then((data) => {
      this.reloadFunds();
      this.betValue = 1;
      this.selectedCoefficients.splice(0, this.selectedCoefficients.length);
    })

  }

}
