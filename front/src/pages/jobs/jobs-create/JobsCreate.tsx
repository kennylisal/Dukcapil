import { Button, Container, Stack } from "@mui/material";
import { PageHeader } from "../../../components/page-header/PageHeader";
// import { useCallback, useRef } from "react";

// import type { JobsFormSchema } from "../../../widgets/jobs/jobs-form/formSchema.ts";
import JobsForm from "../../../widgets/jobs/jobs-form/JobsForm.tsx";

export default function JobsCreate() {
  // const formRef = useRef<HTMLFormElement | null>(null);
  // const navigate = useNavigate();

  // const handleCreatePost = useCallback((data: JobsFormSchema) => {
  //   console.log(data);
  // }, []);

  // const handlePublish = () => {
  //   formRef.current && formRef.current?.requestSubmit();
  //   console.log('Publish');
  // };

  return (
    <Container>
      <PageHeader
        title={"Create Job"}
        breadcrumbs={["Jobs", "Create"]}
        renderRight={
          <Stack direction={"row"} justifyContent={"flex-end"} spacing={2}>
            <Button variant={"outlined"} color={"secondary"}>
              Cancel
            </Button>
            <Button variant={"contained"}>Publish</Button>
          </Stack>
        }
      />

      <JobsForm />
    </Container>
  );
}
