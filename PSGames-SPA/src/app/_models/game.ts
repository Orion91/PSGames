import { Platform } from './platform';

export interface Game {
    id: number;
    title: string;
    gameTitleImageUrl: string;
    platform: Platform;
}
