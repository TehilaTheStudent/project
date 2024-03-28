import styledComponents from 'styled-components'


const MyStyledDiv=styledComponents.div`
display: flex;
`;
const MyStyledFieldSet=styledComponents.fieldset`
background: linear-gradient(90deg, rgba(222, 221, 235, 0.9332983193277311) 0%, rgba(218, 226, 227, 0.8324579831932774) 35%, rgba(240, 240, 240, 0.6615896358543417) 66%, rgb(220 227 228) 100%);
border: 3px solid black;
border-radius: 10px;
`;
const MyStyledLegend=styledComponents.legend`
font-size: 18px;
font-weight: bold;
color: #333;
padding: 5px 10px;
border-radius: 5px;
background-color: #f0f0f0;
margin-bottom: 10px;
display: inline-block;
`;

export { MyStyledLegend,MyStyledFieldSet, MyStyledDiv}