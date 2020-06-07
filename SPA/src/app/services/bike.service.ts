import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Bike } from '../interfaces/bike';

@Injectable()
export class BikeService {

  private url = "https://localhost:44334/api/bike";

  constructor(private http: HttpClient) {
  }

  getBikes() {
    return this.http.get(this.url);
  }

  getBike(id: string) {
    return this.http.get(this.url + '/' + id);
  }

  createBike(bike: Bike) {
    return this.http.post(this.url, bike);
  }

  updateBike(bike: Bike) {
    return this.http.put<Bike>(this.url, bike);
  }

  deleteBike(id: string) {
    return this.http.delete(this.url + '/' + id);
  }

  getTypes() {
    return this.http.get(this.url + '/gettypes');
  }

  getStatuses() {
    return this.http.get(this.url + '/getstatuses');
  }
}
