export const sleep = (duration: number): Promise<void> => {
  return new Promise((resolve) => {
    setTimeout(resolve, duration);
  });
};

export const flashError = (error: Error) => {
  window.alert(error.message);
};
