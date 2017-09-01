import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';

import { RoadService } from '../../services/roads.service';
import { Road } from '../../models/roster/road';

@Component({
    selector: 'roads',
    templateUrl: './roads.component.html'
})
export class RoadsComponent implements OnInit {
    public loading: boolean = false;

    public error: string;
    public success: string;

    public roads: Road[];

    public editingRoad: Road = new Road();

    constructor(private roadService: RoadService) { }

    ngOnInit() {
        this.refreshRoads();
    }

    saveRoad() {
        this.loading = true;
        this.clearMessages();
        
        this.roadService.createRoad(this.editingRoad)
            .subscribe(result => {
                if (result) {
                    this.roads.push(result);

                    this.loading = false;
                    this.success = 'The road has been created';
                }
            }, error => {
                this.error = 'Error creating new road';
                this.loading = false;
            });
    }

    private refreshRoads() {
        this.clearMessages();
        this.roadService.getRoads()
            .subscribe(result => {
                this.roads = result;
            }, error => {
                this.error = 'There was an error retrieving the roads.'
            });
    }

    private clearMessages() {
        this.error = '';
        this.success = '';
    }

    private resetForm() {
        this.editingRoad.id = 0;
        this.editingRoad.name = '';
        this.editingRoad.code = '';
    }
}