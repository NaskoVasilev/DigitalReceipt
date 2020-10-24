<template>
  <div class="container login-container">
      <div class="login-form-1">
        <h2>Login</h2>
        <form>
            <div class="form-group">
                <input type="text" class="form-control" placeholder="Your Email *" value="" />
            </div>
            <div class="form-group">
                <input type="password" class="form-control" placeholder="Your Password *" value="" />
            </div>
            <div class="form-group">
                <input type="submit" class="btnSubmit" value="Login" />
            </div>
            <div class="form-group">
                <a href="/register" class="btn btnRegister">Don't have an account? Register</a>
            </div>
            <div class="form-group">
                <a href="#" class="ForgetPwd">Forget Password?</a>
            </div>
        </form>
      </div>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
    .login-container{
    margin-top: 5%;
    margin-bottom: 5%;
}
.login-form-1{
    padding: 5%;
    box-shadow: 0 5px 8px 0 rgba(0, 0, 0, 0.2), 0 9px 26px 0 rgba(0, 0, 0, 0.19);
}
.login-form-1 h3{
    text-align: center;
    color: #333;
}
.login-container form{
    padding: 10%;
}
.btnSubmit, .btnRegister
{
    width: 50%;
    border-radius: 1rem;
    padding: 1.5%;
    border: none;
    cursor: pointer;
}
.login-form-1 .btnSubmit{
    font-weight: 600;
    color: #fff;
    background-color: #0062cc;
}
.login-form-1 .btnRegister{
    font-weight: 600;
    color: #fff;
    background-color: #b2b2b2;
}
.login-form-1 .ForgetPwd{
    color: #0062cc;
    font-weight: 600;
    text-decoration: none;
}
</style>