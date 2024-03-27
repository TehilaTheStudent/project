import { Grid } from "@mui/material";
import MemberCard from "./SingleMember";
import React, { useRef, useEffect } from "react";


const MemberList = ({ members }) => {
    const gridRef = useRef(null);
    const gridStyle = {
        justifyContent: "center",
        maxHeight:500,
        flexDirection: "column-reverse",
        overflow: "auto"
      };
      useEffect(() => {
        if (gridRef.current) {
          gridRef.current.scrollTo({
            top: gridRef.current.scrollHeight,
            behavior: "smooth",
          });
        }
      }, [members]);
      const sortedMembers = [...members].sort((a, b) => b.id - a.id);
  return (
    <Grid container spacing={0} ref={gridRef} style={gridStyle} sx={{ overflowY: "auto", height: "100%" }}>
      {sortedMembers.map((member) => (
        <Grid item key={member.id} >
          <MemberCard member={member} />
        </Grid>
      ))}
    </Grid>
  );
};
export default MemberList;
