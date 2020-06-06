import { Component, OnInit } from '@angular/core';
import { BikeService } from '../services/bike.service';
import { Bike } from '../interfaces/bike';

@Component({
  selector: 'app-bike',
  templateUrl: './bike.component.html',
  styleUrls: ['./bike.component.css'],
  providers: [BikeService]
})
export class BikeComponent implements OnInit {

  bikes: Bike[];
  bike: Bike = new Bike();

  constructor(private bikeService: BikeService) { }

  ngOnInit() {
    this.getBikes();
  }

  getBikes() {
    this.bikeService.getBikes()
      .subscribe((data: Bike[]) => this.bikes = data);
  }


}
