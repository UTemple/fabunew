begin
  sys.dbms_job.submit(job => :job,
                      what => 'DeleteCloudTimeoutFiles;',
                      next_date => to_date('08-09-2017', 'dd-mm-yyyy'),
                      interval => 'TRUNC(sysdate)+1');
  commit;
end;
/