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

    public Game: Endpoints.Game.IGameService = <any>{};
    public Wallet: Endpoints.Wallet.IWalletService = <any>{};
}
