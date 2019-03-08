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
}
