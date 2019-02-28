import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Enums } from '../../../watts/generated/enums';
import { AngularEndpointsService } from '../../../watts/generated/angular-endpoints.service';

@Component({
  selector: 'sport-handler',
  templateUrl: './sport-handler.component.html',
})

export class SportHandlerComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router, public endpointsService: AngularEndpointsService) {
    route.params.subscribe(params => {
      switch (params['sportName']) {
        case 'football':
          this.sportType = Enums.SportType.Football;
          break;
        case 'basketball':
          this.sportType = Enums.SportType.Basketball;
          break;
        case 'handball':
          this.sportType = Enums.SportType.Handball;
          break;
        default:
          this.router.navigate(['']);
      }
    });
  }
  public gameData: null;
  public sportType: Enums.SportType = null;

  ngOnInit() {
    this.endpointsService.Game.GetAllGames().call().then((data) => {
      this.gameData = this.gameData;
    })
  }

}
