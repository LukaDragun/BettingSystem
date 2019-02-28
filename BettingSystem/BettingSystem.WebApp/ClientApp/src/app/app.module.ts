import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SportHandlerComponent } from './sport-handler/sport-handler.component';
import { AngularEndpointsService } from '../../watts/generated/angular-endpoints.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    SportHandlerComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    
    NgbModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: CounterComponent, pathMatch: 'full' },
      { path: 'sport/:sportName', component: SportHandlerComponent },
      { path: 'wallet', component: CounterComponent },
      { path: 'bets', component: FetchDataComponent, pathMatch: 'full' },
      { path: 'bets/:betId', component: FetchDataComponent },
    ])
  ],
  providers: [AngularEndpointsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
