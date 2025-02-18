
@$(BLUEPRINT_FILENAME).timer_trigger(schedule="$(SCHEDULE_INPUT)", arg_name="myTimer", run_on_startup=True,
              use_monitor=False) 
def $(FUNCTION_NAME_INPUT)(myTimer: func.TimerRequest) -> None:
    if myTimer.past_due:
        logging.info('The timer is past due!')

    logging.info('Python timer trigger function executed.')