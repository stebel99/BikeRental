import { Component, OnInit } from '@angular/core';
import { BikeService } from '../services/bike.service';
import { Bike } from '../interfaces/bike';
import { Type } from '../interfaces/type';
import { Status } from '../interfaces/status';

@Component({
  selector: 'app-bike',
  templateUrl: './bike.component.html',
  styleUrls: ['./bike.component.css'],
  providers: [BikeService]
})
export class BikeComponent implements OnInit {

  statuses: Status[];
  types: Type[];
  bikes: Bike[];
  bike: Bike = new Bike();

  constructor(private bikeService: BikeService) { }

  ngOnInit() {
    this.getBikes();
    this.getStatuses();
    this.getTypes();
  }

  getBikes() {
    this.bikeService.getBikes()
      .subscribe((data: Bike[]) => this.bikes = data);
  }
  getStatuses() {
    this.bikeService.getStatuses()
      .subscribe((data: Status[]) => this.statuses = data);
  }
  getTypes() {
    this.bikeService.getTypes()
      .subscribe((data: Type[]) => this.types = data);
  }

}
