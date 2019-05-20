import { Component, OnInit } from '@angular/core';
import { Game } from 'src/app/_models/game';
import { GameService } from 'src/app/_services/game.service';

@Component({
  selector: 'app-user-game-library',
  templateUrl: './user-game-library.component.html',
  styleUrls: ['./user-game-library.component.css']
})
export class UserGameLibraryComponent implements OnInit {
  games: Game[];
  id: any;

  constructor(private gameService: GameService) { }

  ngOnInit() {
    this.id = localStorage.getItem('userId');
    this.loadGames(this.id);
  }

  loadGames(id) {
    this.gameService.getUserGameLibrary(id).subscribe((games: Game[]) => {
      this.games = games;
    });
  }
}
