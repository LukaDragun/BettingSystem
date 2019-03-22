import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SportHandlerComponent } from './sport-handler/sport-handler.component';
import { AngularEndpointsService } from '../../watts/generated/angular-endpoints.service';
import { EnumToArrayPipe } from './pipes/enumToArray.pipe';
import { CurrentBetService } from './current-bet/current-bet.service';
import { CurrentBetComponent } from './current-bet/current-bet.component';
import { Ng5SliderModule } from 'ng5-slider';
import { WalletComponent } from './wallet/wallet.component';
import { BetListComponent } from './bet-list/bet-list.component';
import { BetDetailsComponent } from './bet-details/bet-details.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    EnumToArrayPipe,
    HomeComponent,
    WalletComponent,
    SportHandlerComponent,
    CurrentBetComponent,
    BetListComponent,
    BetDetailsComponent
  ],
  imports: [
    Ng5SliderModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'sport/:sportName', component: SportHandlerComponent },
      { path: 'current-bet', component: CurrentBetComponent },
      { path: 'wallet', component: WalletComponent },
      { path: 'bets', component: BetListComponent, pathMatch: 'full' },
      { path: 'bets/:betId', component: BetDetailsComponent },
    ])
  ],
  providers: [AngularEndpointsService, CurrentBetService],
  bootstrap: [AppComponent]
})
export class AppModule { }
