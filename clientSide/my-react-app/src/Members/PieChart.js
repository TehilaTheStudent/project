import * as React from 'react';
import { PieChart } from '@mui/x-charts/PieChart';
 //npm install @mui/x-charts
 
export default function BasicPie({ vaccinated, notVaccinated }) {
    const data = [
        { id: 0, value: vaccinated, label: 'vaccinated members' ,color:'green'},
        { id: 1, value: notVaccinated, label: 'not vaccinated at all',color:'red' },

    ];
    return (
        <PieChart
            series={[
                {
                    data,
                    highlightScope: { faded: 'global', highlighted: 'item' },
                    faded: { innerRadius: 30, additionalRadius: -30, color: 'gray' },
                },
            ]}
            height={200}
            width={500}
        />
    );
}