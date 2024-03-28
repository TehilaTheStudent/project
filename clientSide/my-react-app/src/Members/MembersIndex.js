import React, { useState, useEffect } from 'react'
import axios from 'axios'
import { MyStyledDiv ,MyStyledFieldSet,MyStyledLegend} from './Styles/CustomStyles'
import MemberList from './Memberslist'
import Form from './Addmember'
import PieChart from './PieChart'
import Graph from './Graph'
import './Styles/AllCompStyle.css'

export default () => {
    const [membersList, setMembersList] = useState([])
    const [count, setCount] = useState(0)
    const [illData, setIllData] = useState([])

    useEffect(() => {
        const asyncGo = async () => { await getFromServer() }
        asyncGo();
        getVaccinatedCountFromServer();
        getIllEachDay();
    }, [])
    const baseUrl = "https://localhost:7095/HMO/Member"

    const getFromServer = async () => {
        try {
            const response = await axios.get(baseUrl);
            setMembersList(response.data);
            console.log(response.data)
        } catch (error) {
            console.error("Error fetching data:", error);
        }
    };
    const getIllEachDay = async () => {
        try {
            const response = await axios.get("https://localhost:7095/HMO/KoronaDisease/CountIllEachDay");
            setIllData(response.data)
        } catch (error) {
            console.error("Error fetching data:", error);
        }
    }

    const getVaccinatedCountFromServer = async () => {
        try {
            const response = await axios.get(baseUrl + "/CountNotVaccinated");
            setCount(response.data.countNotVaccinated)
        } catch (error) {
            console.error("Error fetching data:", error);
        }
    }
    const onSubmit = async (data) => {
        console.log(data)
        const formData = new FormData();
        formData.append("ImageFile", data.imageFile[0]);
        formData.append("FullName", data.fullName)
        formData.append("IdNumber", data.idNumber)
        formData.append("City", data.city)
        formData.append("Street", data.street)
        formData.append("HouseNumber", data.houseNumber)
        formData.append("BirthDate", data.birthDate)
        formData.append("PhoneNumber", data.phoneNumber)
        formData.append("MobilePhoneNumber", data.mobilePhoneNumber)


        try {
            const response = await axios.post(baseUrl, formData, {
                headers: {
                    "Content-Type": "multipart/form-data",
                },
            });

            console.log(response.data);
        } catch (error) {
            console.error(error);
        }
        await getFromServer();
        await getVaccinatedCountFromServer();
        await getIllEachDay();
    }

    return <>
      <div className="bodyDiv">
      <h1 className='centerHeader'>Bonus Question</h1>
      <div className="outerDiv">
            <MyStyledFieldSet>
                <MyStyledLegend>all members</MyStyledLegend>
            <MemberList members={membersList}></MemberList>
            </MyStyledFieldSet>
            <MyStyledFieldSet>
                <MyStyledLegend>add new member from</MyStyledLegend>  <Form onSubmit={onSubmit}></Form>
            </MyStyledFieldSet>
             <MyStyledFieldSet>
                <MyStyledLegend>how many sick members each day last month</MyStyledLegend> 
                <MyStyledDiv><Graph illnessData={illData}></Graph></MyStyledDiv>
            </MyStyledFieldSet>
            <MyStyledFieldSet>
                <MyStyledLegend>how many members not vaccinated</MyStyledLegend> 
                <MyStyledDiv><PieChart vaccinated={membersList.length - count} notVaccinated={count}></PieChart></MyStyledDiv>
            </MyStyledFieldSet>
           
          </div>
        </div>
    </>
}


