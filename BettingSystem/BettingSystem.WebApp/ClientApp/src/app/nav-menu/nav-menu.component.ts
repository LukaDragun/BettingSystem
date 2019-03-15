import { Component } from '@angular/core';
import { CurrentBetService } from '../current-bet/current-bet.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html'
})

export class NavMenuComponent {
  constructor(public currentBetService: CurrentBetService) { }

  public getCurrentBetCount = () => this.currentBetService.getCurrentBetCount();

}
