import * as _ from 'lodash';
import { Interfaces } from './interfaces';
import { Enums } from './enums';

export namespace Endpoints {
    export interface IEndpoint {
        _verb: string;
        toString(): string;
    }

    function addParameter(parameters: string[], key: string, value: any) {
        if (value == null) {
            return;
        }
    
        if (_.isArray(value)) {
            var encodedItems = _.map(value, (item: any) => encodeURIComponent(item.toString()));
            _(encodedItems).each(item => parameters.push(`${key}=${item}`));
        }
    
        else if (_.isObject(value) && value.getQueryParams) {
            addParameter(parameters, key, value.getQueryParams());
        }
    
        else if (_.isObject(value)) {
            Object.keys(value).forEach((key) => { addParameter(parameters, key, value[key]); });
        }
        else {
            parameters.push(`${key}=${encodeURIComponent(value.toString())}`);
        }
    }

    export namespace Bet {
        export interface IBetService {
            PlaceBet: (args?: IPlaceBet) => IPlaceBetWithCall
        }
    
        export interface IPlaceBet {
        }
    
        export interface IPlaceBetEndpoint extends IPlaceBet, IEndpoint {
        }
    
        export interface IPlaceBetCtor {
            new(args?: IPlaceBet): IPlaceBetEndpoint
        }
    
        export interface IPlaceBetWithCall extends IPlaceBet, IEndpoint {
            call<TView>(dto: Interfaces.IBetDto): Promise<TView>;
        }
    
        export var PlaceBet : IPlaceBetCtor = <any>(function(args?: IPlaceBet) {
            this._verb = 'POST';
        });
    
        PlaceBet.prototype.toString = function(): string {
            return `api/Bet/placeBet`;
        }
    }

    export namespace Game {
        export interface IGameService {
            GetAllGames: (args?: IGetAllGames) => IGetAllGamesWithCall
        }
    
        export interface IGetAllGames {
            sportType?: Enums.SportType;
        }
    
        export interface IGetAllGamesEndpoint extends IGetAllGames, IEndpoint {
        }
    
        export interface IGetAllGamesCtor {
            new(args?: IGetAllGames): IGetAllGamesEndpoint
        }
    
        export interface IGetAllGamesWithCall extends IGetAllGames, IEndpoint {
            call<TView>(): Promise<TView>;
        }
    
        export var GetAllGames : IGetAllGamesCtor = <any>(function(args?: IGetAllGames) {
            this._verb = 'GET';
            this.sportType = args != null ? args.sportType : null;
        });
    
        GetAllGames.prototype.getQueryString = function(): string {
            var parameters: string[] = [];
            addParameter(parameters, 'sportType', this.sportType);
        
            if (parameters.length > 0) {
                return '?' + parameters.join('&');
            }
        
            return '';
        }
    
        GetAllGames.prototype.toString = function(): string {
            return `api/Game` + this.getQueryString();
        }
    }

    export namespace Wallet {
        export interface IWalletService {
            AddFunds: (args?: IAddFunds) => IAddFundsWithCall
            GetTotalFunds: (args?: IGetTotalFunds) => IGetTotalFundsWithCall
        }
    
        export interface IAddFunds {
            value: number;
        }
    
        export interface IAddFundsEndpoint extends IAddFunds, IEndpoint {
        }
    
        export interface IAddFundsCtor {
            new(args?: IAddFunds): IAddFundsEndpoint
        }
    
        export interface IAddFundsWithCall extends IAddFunds, IEndpoint {
            call<TView>(): Promise<TView>;
        }
    
        export var AddFunds : IAddFundsCtor = <any>(function(args?: IAddFunds) {
            this._verb = 'POST';
            this.value = args != null ? args.value : null;
        });
    
        AddFunds.prototype.getQueryString = function(): string {
            var parameters: string[] = [];
            addParameter(parameters, 'value', this.value);
        
            if (parameters.length > 0) {
                return '?' + parameters.join('&');
            }
        
            return '';
        }
    
        AddFunds.prototype.toString = function(): string {
            return `api/Wallet/addFunds` + this.getQueryString();
        }
    
        export interface IGetTotalFunds {
            includeTransactions?: boolean;
        }
    
        export interface IGetTotalFundsEndpoint extends IGetTotalFunds, IEndpoint {
        }
    
        export interface IGetTotalFundsCtor {
            new(args?: IGetTotalFunds): IGetTotalFundsEndpoint
        }
    
        export interface IGetTotalFundsWithCall extends IGetTotalFunds, IEndpoint {
            call<TView>(): Promise<TView>;
        }
    
        export var GetTotalFunds : IGetTotalFundsCtor = <any>(function(args?: IGetTotalFunds) {
            this._verb = 'GET';
            this.includeTransactions = args != null ? args.includeTransactions : null;
        });
    
        GetTotalFunds.prototype.getQueryString = function(): string {
            var parameters: string[] = [];
            addParameter(parameters, 'includeTransactions', this.includeTransactions);
        
            if (parameters.length > 0) {
                return '?' + parameters.join('&');
            }
        
            return '';
        }
    
        GetTotalFunds.prototype.toString = function(): string {
            return `api/Wallet` + this.getQueryString();
        }
    }
}
