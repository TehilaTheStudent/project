import React, { startTransition, useState } from "react";
import { useForm } from "react-hook-form";
import { TextField, Button, Grid, Snackbar } from "@mui/material";
import Alert from '@mui/material/Alert';
const MemberForm = ({ onSubmit }) => {

  const [successMessage, setSuccessMessage] = useState("");
  const [status, setStatus] = useState(0);

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm();

  const onSubmitForm = async (data) => {
    try {
      const response = await onSubmit(data);
      if (response == 201) {
        setStatus(201)
        setSuccessMessage("A new member was added successfully");
        reset(); // Reset the form after successful submission
        setTimeout(() => {
          setSuccessMessage("");

        }, 5000); // Hide the success message after 5 seconds (5000 milliseconds)
      }
      else {
        setSuccessMessage(response.message);
        setStatus(response.status)
        console.log(status)
        setTimeout(() => {
          setSuccessMessage("");

        }, 5000); // Hide the success message after 5 seconds (5000 milliseconds)
      }
    }
    catch (error) {
      console.error(error);
    }
  };

  const handleCloseSnackbar = () => {
    setSuccessMessage("");
  };

  const validateImageFileType = (file) => {
    if (!file) return true; // If no file is selected, consider it valid
    const allowedTypes = ["image/jpeg", "image/png", "image/gif"];
    return file.length == 0 || allowedTypes.includes(file[0].type);
  };

  return (
    <form onSubmit={handleSubmit(onSubmitForm)}>
      <Grid container spacing={2}>
        <Grid item xs={12}>
          <TextField
            sx={{
              "& .MuiInputBase-input": {
                fontSize: "0.8rem", // Adjust the font size as needed
                padding: "6px 8px", // Adjust the padding as needed
              },
              "& .MuiInputLabel-root": {
                fontSize: "0.8rem", // Adjust the label font size as needed
              },
            }}
            {...register("fullName", { required: true })}
            label="Full Name"
            fullWidth
            size="small"
            error={!!errors.fullName}
            helperText={errors.fullName ? "This field is required" : ""}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField
            sx={{
              "& .MuiInputBase-input": {
                fontSize: "0.8rem", // Adjust the font size as needed
                padding: "6px 8px", // Adjust the padding as needed
              },
              "& .MuiInputLabel-root": {
                fontSize: "0.8rem", // Adjust the label font size as needed
              },
            }}
            {...register("idNumber", {
              required: true,
              pattern: {
                value: /^\d{9}$/,
                message: "ID Number must be 9 digits",
              },
            })}
            label="ID Number"
            fullWidth
            size="small"
            error={!!errors.idNumber}
            helperText={errors.idNumber ? errors.idNumber.message : ""}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField
            sx={{
              "& .MuiInputBase-input": {
                fontSize: "0.8rem", // Adjust the font size as needed
                padding: "6px 8px", // Adjust the padding as needed
              },
              "& .MuiInputLabel-root": {
                fontSize: "0.8rem", // Adjust the label font size as needed
              },
            }}
            {...register("city", { required: true })}
            label="City"
            fullWidth
            size="small"
            error={!!errors.city}
            helperText={errors.city ? "This field is required" : ""}
          />
        </Grid>
        <Grid item xs={12}>
          <TextField
            sx={{
              "& .MuiInputBase-input": {
                fontSize: "0.8rem", // Adjust the font size as needed
                padding: "6px 8px", // Adjust the padding as needed
              },
              "& .MuiInputLabel-root": {
                fontSize: "0.8rem", // Adjust the label font size as needed
              },
            }}
            {...register("street", { required: true })}
            label="Street"
            fullWidth
            size="small"
            error={!!errors.street}
            helperText={errors.street ? "This field is required" : ""}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField
            sx={{
              "& .MuiInputBase-input": {
                fontSize: "0.8rem", // Adjust the font size as needed
                padding: "6px 8px", // Adjust the padding as needed
              },
              "& .MuiInputLabel-root": {
                fontSize: "0.8rem", // Adjust the label font size as needed
              },
            }}
            {...register("houseNumber", { required: true })}
            label="House Number"
            fullWidth
            size="small"
            error={!!errors.houseNumber}
            helperText={errors.houseNumber ? "This field is required" : ""}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField
            sx={{
              "& .MuiInputBase-input": {
                fontSize: "0.8rem", // Adjust the font size as needed
                padding: "6px 8px", // Adjust the padding as needed
              },
              "& .MuiInputLabel-root": {
                fontSize: "0.8rem", // Adjust the label font size as needed
              },
            }}
            {...register("birthDate", {
              required: true,
              max: {
                value: new Date().toISOString().split("T")[0],
                message: "Birth Date cannot be later than today",
              },
            })}
            label="Birth Date"
            type="date"
            fullWidth
            size="small"
            InputLabelProps={{
              shrink: true,
            }}
            error={!!errors.birthDate}
            helperText={errors.birthDate ? errors.birthDate.message : ""}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField
            sx={{
              "& .MuiInputBase-input": {
                fontSize: "0.8rem", // Adjust the font size as needed
                padding: "6px 8px", // Adjust the padding as needed
              },
              "& .MuiInputLabel-root": {
                fontSize: "0.8rem", // Adjust the label font size as needed
              },
            }}
            {...register("phoneNumber", {
              required: true,
              pattern: {
                value: /^\d{9}$/,
                message: "Phone Number must be 9 digits",
              },
            })}
            label="Phone Number"
            fullWidth
            size="small"
            error={!!errors.phoneNumber}
            helperText={errors.phoneNumber ? errors.phoneNumber.message : ""}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField
            sx={{
              "& .MuiInputBase-input": {
                fontSize: "0.8rem", // Adjust the font size as needed
                padding: "6px 8px", // Adjust the padding as needed
              },
              "& .MuiInputLabel-root": {
                fontSize: "0.8rem", // Adjust the label font size as needed
              },
            }}
            {...register("mobilePhoneNumber", {
              required: true,
              pattern: {
                value: /^\d{10}$/,
                message: "Mobile Phone Number must be 10 digits",
              },
            })}
            label="Mobile Phone Number"
            fullWidth
            size="small"
            error={!!errors.mobilePhoneNumber}
            helperText={errors.mobilePhoneNumber ? errors.mobilePhoneNumber.message : ""}
          />
        </Grid>
        <Grid item xs={12}>
          <TextField
            sx={{
              "& .MuiInputBase-input": {
                fontSize: "0.8rem", // Adjust the font size as needed
                padding: "6px 8px", // Adjust the padding as needed
              },
              "& .MuiInputLabel-root": {
                fontSize: "0.8rem", // Adjust the label font size as needed
              },
            }}
            {...register("imageFile", {
              validate: {
                validFileType: validateImageFileType,
              },
            })}
            label="Image File (Optional)"
            type="file"
            fullWidth
            size="small"
            error={!!errors.imageFile}
            helperText={
              errors.imageFile
                ? errors.imageFile.type === "validFileType"
                  ? "File must be a valid image type (jpeg, png, gif)"
                  : "This field is required"
                : ""
            }
          />
        </Grid>
        <Grid item xs={12}>
          <Button type="submit" variant="contained" color="primary" size="small">
            Submit
          </Button>
        </Grid>
      </Grid>
    
      <Snackbar
        open={!!successMessage}
        autoHideDuration={5000}
        onClose={handleCloseSnackbar}
        message={successMessage}
        anchorOrigin={{
          vertical: 'bottom',
          horizontal: 'center',
        }}
      >
        {status != 201 ? <Alert variant="filled" severity="error">
          <p>status: {status}</p>
          <p>       {successMessage}
          </p>
        </Alert> : <Alert variant="filled" severity="success">
          {successMessage}
        </Alert>}


      </Snackbar>
    </form>
  );
};

export default MemberForm;
