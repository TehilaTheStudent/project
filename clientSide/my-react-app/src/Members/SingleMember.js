


import React from "react";
import { Card, CardContent, Typography, Table, TableBody, TableCell, TableRow,Avatar } from "@mui/material";

const MemberCard = ({ member }) => {
  const cardStyle = {
    width: 400,
    margin: "16px",
    boxShadow: "0 4px 8px rgba(0, 0, 0, 0.1)",
    transition: "transform 0.2s",
    "&:hover": {
      transform: "scale(1.02)",
    },
  };
  const keyStyle = {
    fontWeight: "bold",
  };
  return (
    <Card style={cardStyle} variant="outlined">
      <CardContent>
      {<Avatar alt={member.fullName} src={member.imageUrl} />}
        <Typography variant="h5" component="div">
          {member.name}
        </Typography>
        <Table size="small" dense="true">
          <TableBody>
            <TableRow>
              <TableCell  style={keyStyle}>Id:</TableCell>
              <TableCell>{member.id}</TableCell>
            </TableRow>
            <TableRow>
              <TableCell  style={keyStyle}>Fullname:</TableCell>
              <TableCell>{member.fullName}</TableCell>
            </TableRow>
            <TableRow>
              <TableCell  style={keyStyle}>IdNumber:</TableCell>
              <TableCell>{member.idNumber}</TableCell>
            </TableRow>
            <TableRow>
              <TableCell  style={keyStyle}>City:</TableCell>
              <TableCell>{member.city}</TableCell>
            </TableRow>
            <TableRow>
              <TableCell  style={keyStyle}>Street:</TableCell>
              <TableCell>{member.street}</TableCell>
            </TableRow>
            <TableRow>
              <TableCell  style={keyStyle}>HouseNumber:</TableCell>
              <TableCell>{member.houseNumber}</TableCell>
            </TableRow>
            <TableRow>
              <TableCell  style={keyStyle}>BirthDate:</TableCell>
              <TableCell>{member.birthDate}</TableCell>
            </TableRow>
            <TableRow>
              <TableCell  style={keyStyle}>PhoneNumber:</TableCell>
              <TableCell>{member.phoneNumber}</TableCell>
            </TableRow>  
             <TableRow>
              <TableCell  style={keyStyle}>MobilePhoneNumber:</TableCell>
              <TableCell>{member.mobilePhoneNumber}</TableCell>
            </TableRow>
        
          </TableBody>
        </Table>
      </CardContent>
    </Card>
  );
};

export default MemberCard;
