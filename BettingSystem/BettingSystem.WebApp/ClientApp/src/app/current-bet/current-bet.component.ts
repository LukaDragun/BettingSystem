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

  value: number = 100;
  options: Options = {
    floor: 0,
    ceil: 250
  };

  public currentBets: IBetCoefficientView[];

  constructor(private currentBetService: CurrentBetService) {
    this.currentBets = this.currentBetService.currentBets;
  }

  public removeCoefficient = (index: number) => this.currentBets.splice(index,1);

  ngOnInit() {
  }

}
