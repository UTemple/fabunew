create or replace procedure DeleteCloudTimeoutFiles is
begin
  delete from CLOUDDISK where UPTIME < sysdate-7;
end DeleteCloudTimeoutFiles;
/
