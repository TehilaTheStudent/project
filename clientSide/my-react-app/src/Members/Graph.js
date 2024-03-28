import * as React from 'react';
import { LineChart } from '@mui/x-charts/LineChart';



export default function SimpleLineChart({ illnessData }) {
    const dates = Object.keys(illnessData);//get arr all the dates
    const values = Object.values(illnessData);//get arr of all the numbers

    const formattedDates = dates.map((date) => {//arr of dates to be labels for the graph
        const formattedDate = new Date(date);
        let month=formattedDate.getMonth()+1;
        return formattedDate.getDate()+"/"+month+"\n"+formattedDate.getFullYear();
    });
    const uData =values//numbers-Y
    const xLabels = formattedDates//dates-X

    return (
        <LineChart
            width={900}
            height={300}
            series={[
                { data: uData, label: 'sick members' },   
            ]}
            xAxis={[{ scaleType: 'point', data: xLabels }]}
           
        />
    );
}
