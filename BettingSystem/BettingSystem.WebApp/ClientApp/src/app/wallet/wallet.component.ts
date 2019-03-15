import { Component, OnInit } from "@angular/core";
import { AngularEndpointsService } from "../../../watts/generated/angular-endpoints.service";
import { Options } from "ng5-slider";
import { Interfaces } from '../../../watts/generated/interfaces';
import { Enums } from "../../../watts/generated/enums";

@Component({
  selector: 'wallet',
  templateUrl: './wallet.component.html'
})
export class WalletComponent implements OnInit {
  public funds: Interfaces.ITotalFundsView = null;
  public transactionTypes: typeof Enums.TransactionType = Enums.TransactionType;

  constructor(public endpointsService: AngularEndpointsService) {
  }

  ngOnInit() {
    this.reloadData();
  }

  addFundsValue: number = 0;
  options: Options = {
    floor: 1,
    ceil: 1000
  };

  reloadData() {
    this.endpointsService.Wallet.GetTotalFunds().call<Interfaces.ITotalFundsView>().then((data) => {
      this.funds = data;
    })
  }


  public addFunds = () => {
    this.endpointsService.Wallet.AddFunds({ value: this.addFundsValue }).call().then(() => this.reloadData())
  }
}
