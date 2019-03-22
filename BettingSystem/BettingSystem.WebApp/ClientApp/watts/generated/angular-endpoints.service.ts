import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import * as _ from 'lodash';
import { Endpoints } from './endpoints';

import { Interfaces } from './interfaces';

@Injectable()
export class AngularEndpointsService {
    constructor(http: HttpClient) {
        this.Bet.PlaceBet = (args?: Endpoints.Bet.IPlaceBet): Endpoints.Bet.IPlaceBetWithCall => {
            var endpoint = new Endpoints.Bet.PlaceBet(args);
            return _.extend(endpoint, {
                call<TView>(dto: Interfaces.IBetDto) {
                    return AngularEndpointsService.call<TView>(http, this, dto != null ? dto : null);
                }
            });
        };
    
        this.Bet.GetBets = (args?: Endpoints.Bet.IGetBets): Endpoints.Bet.IGetBetsWithCall => {
            var endpoint = new Endpoints.Bet.GetBets(args);
            return _.extend(endpoint, {
                call<TView>() {
                    return AngularEndpointsService.call<TView>(http, this, null);
                }
            });
        };
    
        this.Bet.GetBet = (args: Endpoints.Bet.IGetBet): Endpoints.Bet.IGetBetWithCall => {
            var endpoint = new Endpoints.Bet.GetBet(args);
            return _.extend(endpoint, {
                call<TView>() {
                    return AngularEndpointsService.call<TView>(http, this, null);
                }
            });
        };
    
        this.Game.GetAllGames = (args?: Endpoints.Game.IGetAllGames): Endpoints.Game.IGetAllGamesWithCall => {
            var endpoint = new Endpoints.Game.GetAllGames(args);
            return _.extend(endpoint, {
                call<TView>() {
                    return AngularEndpointsService.call<TView>(http, this, null);
                }
            });
        };
    
        this.Wallet.AddFunds = (args: Endpoints.Wallet.IAddFunds): Endpoints.Wallet.IAddFundsWithCall => {
            var endpoint = new Endpoints.Wallet.AddFunds(args);
            return _.extend(endpoint, {
                call<TView>() {
                    return AngularEndpointsService.call<TView>(http, this, null);
                }
            });
        };
    
        this.Wallet.GetTotalFunds = (args?: Endpoints.Wallet.IGetTotalFunds): Endpoints.Wallet.IGetTotalFundsWithCall => {
            var endpoint = new Endpoints.Wallet.GetTotalFunds(args);
            return _.extend(endpoint, {
                call<TView>() {
                    return AngularEndpointsService.call<TView>(http, this, null);
                }
            });
        };
    }

    static call<TView>(http: HttpClient, endpoint: Endpoints.IEndpoint, data) {
        const options: any  =  {
            method: endpoint._verb,
            url: endpoint.toString()
        }
    
        if(endpoint._verb == 'GET') {
            options.params = data;
        }
        else {
            options.body = data;
        }
    
        const call: Observable<any> = http.request(options.method, options.url, options);
        return call.toPromise();
    }

    public Bet: Endpoints.Bet.IBetService = <any>{};
    public Game: Endpoints.Game.IGameService = <any>{};
    public Wallet: Endpoints.Wallet.IWalletService = <any>{};
}
