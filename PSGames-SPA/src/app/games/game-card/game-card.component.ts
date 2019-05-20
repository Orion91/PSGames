import { Component, OnInit, Input } from '@angular/core';
import { Game } from 'src/app/_models/game';
import { GameService } from 'src/app/_services/game.service';

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrls: ['./game-card.component.css']
})
export class GameCardComponent implements OnInit {
  @Input() game: Game;

  constructor(private gameService: GameService) { }

  ngOnInit() {
  }

  addGameToUserLibrary() {
    console.log('Adding game to library');
    this.gameService.addGameToUserLibrary(+localStorage.getItem('userId'), this.game.id).subscribe(next => {
      console.log('Game added succesfully');
    }, error => {
      console.log(error);
    });
  }

}
