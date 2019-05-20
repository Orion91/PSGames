import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Game } from '../_models/game';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  baseUrl = environment.apiUrl + 'games/';

constructor(private http: HttpClient) { }

getAllGames(): Observable<Game[]> {
  return this.http.get<Game[]>(this.baseUrl);
}

getGame(id): Observable<Game> {
  return this.http.get<Game>(this.baseUrl + id);
}

getUserGameLibrary(id): Observable<Game[]> {
  return this.http.get<Game[]>(this.baseUrl + 'library/' + id);
}

addGameToUserLibrary(userId: number, gameId: number) {
  console.log(this.baseUrl + 'library/' + userId + '/add/' + gameId);
  return this.http.post(this.baseUrl + 'library/' + userId + '/add/' + gameId, {});
}

}
