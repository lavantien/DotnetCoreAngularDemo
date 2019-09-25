import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {CommonService} from '../services/common.service';

@Component({
    selector: 'app-test',
    templateUrl: './test.component.html',
    styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {

    tests: ITest[] = [];
    test: string;

    constructor(private http: HttpClient, private common: CommonService) {
    }

    ngOnInit() {
        this.getTests();
        this.test = this.common.testVar;
    }

    getTests() {
        this.http.get<ITest[]>('api/tests').subscribe((res) => {
            this.tests = res;
        });
    }

}

interface ITest {
    id: number;
    name: string;
    value: number;
    date: Date;
    image: string;
    osId: number;
}
