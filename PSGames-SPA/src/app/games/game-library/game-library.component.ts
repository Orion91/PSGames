import { Component, OnInit } from '@angular/core';
import { Game } from 'src/app/_models/game';
import { GameService } from 'src/app/_services/game.service';

@Component({
  selector: 'app-game-library',
  templateUrl: './game-library.component.html',
  styleUrls: ['./game-library.component.css']
})
export class GameLibraryComponent implements OnInit {
  games: Game[];

  constructor(private gameService: GameService) { }

  ngOnInit() {
    this.loadGames();
  }

  loadGames() {
    this.gameService.getAllGames().subscribe((games: Game[]) => {
      this.games = games;
    });
  }


}
