import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Game } from '../_models/game';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

getAllGames(): Observable<Game[]> {
  return this.http.get<Game[]>(this.baseUrl + 'games');
}

getGame(id): Observable<Game> {
  return this.http.get<Game>(this.baseUrl + 'games/' + id);
}

}
