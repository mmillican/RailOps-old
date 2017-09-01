import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';

import { RoadService } from '../../services/roads.service';
import { Road } from '../../models/roster/road';

@Component({
    selector: 'roads',
    templateUrl: './roads.component.html'
})
export class RoadsComponent implements OnInit {
    public roads: Road[];

    public editingRoad: Road = new Road();

    constructor(private roadService: RoadService) { }

    ngOnInit() {
        this.refreshRoads();
    }

    saveRoad() {
        this.roadService.createRoad(this.editingRoad)
            .subscribe(result => {
                if (result) {
                    this.refreshRoads();
                }
            });
    }

    private refreshRoads() {
        this.roadService.getRoads()
            .subscribe(result => {
                this.roads = result;
            });
    }
}