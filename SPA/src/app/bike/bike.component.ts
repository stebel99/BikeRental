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
  rentBikes: Bike[] = [];
  types: Type[];
  availableBikes: Bike[] = [];
  bike: Bike = new Bike();
  totalPrice: number = 0;
  totalNumberAvailableBikes: number = 0;

  constructor(private bikeService: BikeService) { }

  ngOnInit() {
    this.getBikes();
    this.getStatuses();
    this.getTypes();
    for (var i = 0; i < this.rentBikes.length; i++) {
      this.totalPrice += this.rentBikes[i].price;
    }
  }

  cancelRent(b: Bike) {
    b.statusId = 1;
    this.bikeService.updateBike(b)
      .subscribe(result => console.log("Updated"));
  }
  onCreate() {
    this.bikeService.createBike(this.bike)
      .subscribe((data: Bike) => this.availableBikes.push(data));
    this.cancel();
  }


  getBikes() {
    this.bikeService.getBikes()
      .subscribe((data: Bike[]) => {
        for (var i = 0; i < data.length; i++) {
          if (data[i].statusId == 2) {
            this.rentBikes.push(data[i]);
            this.totalPrice += data[i].price;
          }
          else {
            this.availableBikes.push(data[i]);
            this.totalNumberAvailableBikes += 1;
          }
        }
      });
  }
  getStatuses() {
    this.bikeService.getStatuses()
      .subscribe((data: Status[]) => this.statuses = data);
  }
  getTypes() {
    this.bikeService.getTypes()
      .subscribe((data: Type[]) => this.types = data);
  }

  cancel() {
    this.bike = new Bike();
  }

}
